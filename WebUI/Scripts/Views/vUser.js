function vUser() {

    const inputClave = document.querySelector('#txtPassword');
    const inputConfirma = document.querySelector('#txtConfirmPass');
    var userLoginData = JSON.parse(sessionStorage.getItem("user"));

    this.tblUsersId = 'tblUsers';
    this.service = 'user';
    this.serviceActivate = "user/Activar";
    this.ctrlActions = new ControlActions();
    this.columns = "ID,FirstName,SecondName,LastName1,LastName2,Email,BirthDate,PhoneNumber,Password,Confirm";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblUsersId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblUsersId, true);
    }

    this.Create = function () {
        var userData = this.ctrlActions.GetDataForm('frmEdition');
        if (!userData) {
            return false;
        }
        if (userData.Password != userData.Confirm ) {

            inputClave.classList.add('is-invalid');
            inputConfirma.classList.add('is-invalid');

            Swal.fire({
                title: 'An error has occurred',
                text: 'Passwords doesn\'t match. Please check the information and try again.',
                type: 'warning',
                confirmButtonText: 'OK'
            });
        } else {
            inputClave.classList.remove('is-invalid');
            inputConfirma.classList.remove('is-invalid');
            $('#container-spinner').removeClass('d-none');
              
            var CtrlActions = this.ctrlActions;
            $.post(this.ctrlActions.GetUrlApiService(this.service), userData, function (response) {
                Swal.fire({
                    title: 'Thanks for joining SafeFly!',
                    text: 'We will send you a welcome email, now you can Log In with your email and password.',
                    type: 'success',
                    confirmButtonText: 'Ok'
                  }).then((result) => {
                          window.location.href = '/LogIn/user';
                  });
                  
                   CtrlActions.PostToAPI("userxrolexview", {
                        "UserId": userData.ID,
                        "RoleId": 1,
                        "ViewId": 4
                   });
            
            }).fail(function (response) {
                 var data = response.responseJSON;
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

    this.Update = function () {

        var userData = {};
        var vm = this;
        userData = this.ctrlActions.GetDataForm('frmEditionProfile');
   
        $.put(this.ctrlActions.GetUrlApiService(this.service), userData, function (response) {            
            Swal.fire({
                title: 'Complete update porfile',
               type: 'success',
                confirmButtonText: 'OK'
           });
            vm.ShowForm();
        })
        .fail(function (response) {
             var data = response.responseJSON;
               Swal.fire({
                    title: 'An error has occurred',
                    text: 'Please check the information and try again.',
                   type: 'error',
                    confirmButtonText: 'OK'
               });
         })

    }

    this.ShowForm = function () {
        $('#frmEditionProfile').toggleClass("disable-form");
        $('#btnUpdate-profile').toggleClass("d-none");
        $("#frmEditionProfile input[name=txtEmail]").attr("disabled", true)
        $("#frmEditionProfile input[name=txtID]").attr("disabled", true)
    }

    this.Delete = function () {
        $.delete(this.ctrlActions.GetUrlApiService(this.service), userLoginData, function (response) {
            Swal.fire({
                title: 'Complete update porfile',
               type: 'success',
                confirmButtonText: 'OK'
            })
        })
        .fail(function (response) {
             var data = response.responseJSON;
               Swal.fire({
                    title: 'An error has occurred',
                    text: 'Please check the information and try again.',
                   type: 'error',
                    confirmButtonText: 'OK'
               });
         })

    }

    this.Activar = function () {

        var userData = {};
        userData = this.ctrlActions.GetDataForm('frmEdition');
      
        //Hace el post al create
        this.ctrlActions.ActivarToAPI(this.serviceActivate, userData);
        Swal.fire({
            title: 'Activación completa',
            text: 'El usuario se activo correctamente',
            type: 'success',
            confirmButtonText: 'Entendido'
        });
        //Refresca la tabla
        this.ReloadTable();

    }

    this.BindFields = function () {
        if ($('#frmEditionProfile').length) {
            this.ctrlActions.BindFields('frmEditionProfile', userLoginData);
        }
    }
}

$(document).ready(function () {

    var vuser = new vUser();
    vuser.BindFields();
   
});
