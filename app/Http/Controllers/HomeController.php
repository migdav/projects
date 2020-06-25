<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\User;
use Illuminate\Support\Facades\Auth;
use DB;

class HomeController extends Controller
{
    /**
     * Create a new controller instance.
     *
     * @return void
     */
    public function __construct()
    {
        $this->middleware('auth');
    }

    /**
     * Show the application dashboard.
     *
     * @return \Illuminate\Contracts\Support\Renderable
     */
    public function index()
    {
        $data = DB::table('transfers')
        ->join('users', 'transfers.to_userID', '=', 'users.id')
        ->select('transfers.created_at', 'users.email', 'transfers.description', 'transfers.amount', 'transfers.transfer_type')
        ->where('transfers.from_userID', '=', Auth::user()->id)
        ->get();

        return view('home', compact('data'));
    }


}
