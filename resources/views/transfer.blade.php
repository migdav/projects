@extends('layouts.app')

@section('content')
<div class="container">
    <div class="row justify-content-center">
        <div class="col-md-8">
            <div class="card">
                <div class="card-header">{{ __('MAKE A BANK TRANSFER') }}</div>

                <div class="card-body">
                    <form method="POST" action="{{ route('transfer.make') }}">
                        @csrf

                        @if(session('success'))
                            <div class="alert alert-success" role='alert' >
                                {{session('success')}}
                            </div>
                        @endif

                        @if(session('danger'))
                            <div class="alert alert-danger" role='alert' >
                                {{session('danger')}}
                            </div>
                        @endif


                        <div class="form-group row">
                            <label for="email" class="col-md-4 col-form-label text-md-right">{{ __('Beneficiary\'s E-Mail Address') }}</label>

                            <div class="col-md-6">
                                <input id="email" type="email" class="form-control @error('email') is-invalid @enderror" name="email" value="{{ old('email') }}" required autocomplete="email" autofocus>

                                @error('email')
                                    <span class="invalid-feedback" role="alert">
                                        <strong>{{ $message }}</strong>
                                    </span>
                                @enderror
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="acc" class="col-md-4 col-form-label text-md-right">{{ __('Beneficiary\'s account') }}</label>

                            <div class="col-md-6">
                                <input id="acc" type="text" class="form-control @error('acc') is-invalid @enderror" name="acc" >

                                @error('acc')
                                    <span class="invalid-feedback" role="alert">
                                        <strong>{{ $message }}</strong>
                                    </span>
                                @enderror
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="number" class="col-md-4 col-form-label text-md-right">{{ __('AMOUNT, €') }}</label>
                            
                            <div class="col-xs-6 col-sm-3">
                                <input id="number" type="number" step ="0.01" class="form-control @error('number') is-invalid @enderror" name="number" >

                                @error('number')
                                    <span class="invalid-feedback" role="alert">
                                        <strong>{{ $message }}</strong>
                                    </span>
                                @enderror
                                <label style="font-size:13px;color:red;" >Max available: {{ number_format((float) Auth::user()-> total, 2)}} €</label>
                            </div>
                            
                        </div>

                        <div class="form-group row">
                            <label for="desc" class="col-md-4 col-form-label text-md-right">{{ __('Description') }}</label>

                            <div class="col-md-6">
                                <input id="desc" type="text" class="form-control @error('desc') is-invalid @enderror" name="desc" >

                                @error('desc')
                                    <span class="invalid-feedback" role="alert">
                                        <strong>{{ $message }}</strong>
                                    </span>
                                @enderror
                            </div>
                        </div>


                        <div class="form-group row mb-0">
                            <div class="col-md-8 offset-md-4">
                                <button type="submit" class="btn btn-primary">
                                    {{ __('Confirm') }}
                                </button>

                                
                            </div>
                            <button type = "submit"class="btn btn-info" style="padding:10px 20px;margin:5px;margin-left : 80%;">
                            <a style="color:black" href="{{ route('home') }}">Back to chat</a></button>
                            </br> </br>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</div>
@endsection
