'use strict';

function vLogIn() {

    var service = 'user/LogIn';
    var serviceEmail = 'user/GetEmail';
    var ctrlActions = new ControlActions();
    this.columns = "UserID,Keyword"
    let email = document.querySelector('#txtEmail');
    let password = document.querySelector('#txtPassword');

    var LimpiarFormulario = function(){
        email.value = '';
        password.value = '';
    }

    var ValidarInputs = function(){
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

    var Views = function (data) {
       if (data.RolName != null) {
            window.location.href = '/Dashboard/user';
        } else {
             window.location.href = '/';
        }
    }
    
    this.SendCredentials = function () {
        ValidarInputs();
        $('#container-spinner').removeClass('d-none');
        var userData = ctrlActions.GetDataForm('frmEdition');
        
        if (!userData) { 
             $('#container-spinner').addClass('d-none');
             return false;
        }
       
       $.login(ctrlActions.GetUrlApiService(service), userData.UserID, userData.Keyword, function (response) {
             $.email(ctrlActions.GetUrlApiService(serviceEmail), userData.UserID, function (response) {
                    sessionStorage.setItem('user', JSON.stringify(response));
                    Views(response);
            })
           .fail(function (response) {
                 $('#container-spinner').addClass('d-none');
                Swal.fire({
                    title: 'An error has occurred',
                    text: 'Please check the information and try again.',
                   type: 'error',
                    confirmButtonText: 'OK'
               });
            })     
       })
       .fail(function (response) {
              $('#container-spinner').addClass('d-none');
              Swal.fire({
                    title: 'An error has occurred',
                    text: 'Please check the information and try again.',
                   type: 'error',
                    confirmButtonText: 'OK'
               });
       })
    }
}