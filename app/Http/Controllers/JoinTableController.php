<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use DB;

class JoinTableController extends Controller
{
    public function index()
    {
        //$data = DB::table('transfers')->get();
        //return DB::table('transfers')->get();
        $data = DB::table('transfers')
                ->join('users', 'transfers.from_userID', '=', 'users.id')
                ->select('transfers.from_userID', 'users.email', 'transfers.description')
                ->get();
        /*$data = DB::table('transfers')
                
                -> select('transfers.created_at, transfers.from_userID', 'transfers.to_userID', 'users.email',
                     'users.amount', 'users.transfer_type', 'users.description')
                ->get();*/
        return view('home', compact('data'));
        //return view('join-table', compact('data'));
    }    
}
?>