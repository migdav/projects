<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Http\Requests;
use App\User;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\DB;
use App\Http\Controllers\Controller;

class TransferController extends Controller
{
    public function index()
    {
        return view('transfer');
    }

    public function make(Request $request)
    {
        //get values from form
        $typed_email = $request['email'];
        $typed_acc = $request['acc'];
        $typed_amount = $request['number'];
        $typed_desc = $request['desc'];
        if(User::where('email', $typed_email)->first())
        {
            //get id and other details of beneficiary 
            $b_id = User::where('email', $typed_email)->first()->id;

            $b_email_according_Id = User::where('id', $b_id)->first()->email;
            $b_iban_according_Id = User::where('id', $b_id)->first()->iban;

            // checking correctness of typed data and DB data
            if ($typed_email === $b_email_according_Id && $typed_acc === $b_iban_according_Id)
            {
                $beneficiary = User::find($b_id);
                $current = User::find(Auth::user()->id);
 
                if ($typed_amount > $current->total)
                {
                    $request-> session()->flash('danger', 'You want to transfer '.$typed_amount.' EUR . The biggest amount you can transfer - '.$current->total .' EUR. Please type amount again.');
                } 
                else if ($typed_amount < 0)
                {
                    $request-> session()->flash('danger', 'Amount can not be less than 0');
                }   
                else if ($typed_amount< $current->total) 
                {
                    try
                    {
                        DB::transaction(function () use ($beneficiary, $typed_amount, $current, $request, $typed_desc) {
                            //addition to beneficiary
                            $beneficiary->total = $beneficiary->total + $typed_amount;
                            $beneficiary->save();
    
                            //substraction from sender
                            $current->total = $current->total - $typed_amount;
                            $current->save();
    
                            // add transfers to db table 'transfers'
                            $today = date("Y-m-d H:i:s");
                                //add transfer addition
                                $resultsA = DB::insert('insert into transfers (from_userID, to_userID, amount, transfer_type, description, created_at, updated_at) values(?, ?, ?, ?, ?, ?, ?)'
                                    , [$current->id, $beneficiary->id, $typed_amount, 0, $typed_desc, $today, $today]);
    
                                //add transfer substraction
                                $resultsB = DB::insert('insert into transfers (from_userID, to_userID, amount, transfer_type, description, created_at, updated_at) values(?, ?, ?, ?, ?, ?, ?)'
                                    , [$beneficiary->id, $current->id, $typed_amount, 1, $typed_desc, $today, $today]);   
    
                            $request-> session()->flash('success', 'Congradulations! You have just made a bank transfer to '.$request['email'].' !');
                            if( !$resultsB )
                            {
                                throw new \Exception('The bank transfer is failed');
                            }
                        });
                    }
                    catch(\Exception $e)
                    {
                        throw $e;                        
                    }
                }         
                
            }
            else
            {
                $request-> session()->flash('danger', 'User\'s ' .$b_email.' IBAN is INCORRECT. Please check it again !');
            }
        }
        else
        {
            $request-> session()->flash('danger', 'Email or IBAN is NOT FOUND in the system. Please check details again !');
        }

        //$request-> session()->flash('success', 'You have just made a bank transfer to '.$request['email'].' !');
        return redirect()-> back();
    }

    
}