@extends('layouts.app')

@section('content')
<div class="container">
    <div class="row justify-content-center">
        <div class="col-md-8">
            <div class="card">
                <div class="card-header">YOUR PROFILE</i></div>

                <div class="card-body">
                    @if (session('status'))
                        <div class="alert alert-success" role="alert">
                            {{ session('status') }}
                        </div>
                    @endif
                    <br>
                    <table style="width:100%">
                    <tr>
                        <th>
                            <h2>
                                <b>Welcome!</b>
                                
                            </h2>
                            <h6> Your Email : {{ Auth::user()-> email}}</h6>                            
                        </th>
                        <th>
                            <h4 style="text-align:center;border:3px; border-style:solid; border-color:#FF0000; padding: 1em;">
                            <b> Total: {{ number_format((float) Auth::user()-> total, 2)}} €<b></h4>
                            <h6 style="text-align:right"><b> Your IBAN : {{ Auth::user()-> iban}}<b></h6>
                        </th> 
                    </tr>
                    <tr>
                        <td>
                            <button type = "submit"class="btn btn-primary" style="padding:10px;margin:10px;margin-right:5%;">
                            <a style="color:white" href="{{ route('transfer') }}">Make a bank transfer</a></button>
                        </td>
                    </tr>
                    
                    </table>

                    <hr>
                    <!--tikrinti, jei nera jokio pavedimo tai rasyti There are no transfers-->
                    <!-- jei yra tai rodyti lista ju-->
                        <div class="table-responsive">
                            <table class = "table table-bordered table-striped">
                                <thread>
                                    <tr>
                                        <th>Date</th>
                                        <th>From/To</th>
                                        <th>Description</th>
                                        <th>Amount, €</th>
                                    </tr>
                                </thread>  
                                <tbody>
                                    @foreach($data as $row)
                                        <tr> 
                                            <td> {{ \Carbon\Carbon::parse($row->created_at)->format('Y-m-d')}}</td>
                                            <td> {{$row->email}}</td>
                                            <td> {{$row->description}}</td> 
                                                @if($row->transfer_type == 0)
                                                     <td style="color:red"> -{{$row->amount}}</td>                                                  
                                                @endif
                                                @if($row->transfer_type == 1)
                                                    <td style="color:green"> +{{$row->amount}}</td>
                                                @endif
                                        </tr>
                                    @endforeach
                                </tbody>                     
                            </table>
                        </div>
                 
                        

                </div>
                
            </div>
            
        </div>
    </div>
</div>
@endsection
