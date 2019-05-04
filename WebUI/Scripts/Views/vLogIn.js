'use strict';

function vLogIn() {

    this.service = 'user/LogIn';
    this.serviceEmail = 'user/GetEmail';
    this.ctrlActions = new ControlActions();
    this.columns = "UserID,Keyword"
    let email = document.querySelector('#txtEmail');
    let password = document.querySelector('#txtPassword');

    this.SendCredentials = function () {

        var userData = {};
        userData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el envia para inicio de sesion
        this.ctrlActions.LogInToAPI(this.service, userData);
        this.ctrlActions.EmailToAPI(this.serviceEmail, userData);
    }

    this.UserSession = function (userData) {
        var array = [];
        for (var prop in userData) {
            array.push(userData[prop]);
        }
        sessionStorage.setItem('user', JSON.stringify(userData));
        this.Views(array)
    }

    this.ValidateCredentials = function (userData, acesso) {

        if (this.ValidarInputs() != true) {
            if (userData != null && acesso == true) {
                sessionStorage.setItem('userEmail', userData[0]);
                sessionStorage.setItem('userPassword', userData[1]);
                Swal.fire({
                    title: 'Welcome!',
                    text: 'Log in successful.',
                    type: 'success',
                    confirmButtonText: 'OK'
                });
            }
        } else {
            Swal.fire({
                title: 'Error',
                text: 'Please check the inputs.',
                type: 'error',
                confirmButtonText: 'OK'
            });
            this.LimpiarFormulario();
        }
    }

    this.LimpiarFormulario = function(){
        email.value = '';
        password.value = '';
    }

    this.ValidarInputs = function(){
        let error = false;

        if (email.value == '') {
            error = true;
            email.classList.add('is-invalid');
        } else {
            email.classList.remove('is-invalid');
        }
        if (password.value == '') {
            error = true;
            password.classList.add('is-invalid');

        } else {
            password.classList.remove('is-invalid');
        }
        return error;
    }

    this.Views = function (array) {
        var rol = array[12];
        
        if (rol != null) {
            window.location.href = '/Dashboard/user';
        } else {
             window.location.href = '/';
        }
    }
}