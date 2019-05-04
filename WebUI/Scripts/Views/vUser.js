function vUser() {

    const inputClave = document.querySelector('#txtPassword');
    const inputConfirma = document.querySelector('#txtConfirmPass');
    var userLoginData = JSON.parse(sessionStorage.getItem("user"));

    this.tblUsersId = 'tblUsers';
    this.service = 'user';
    this.serviceActivate = "user/Activar";
    this.ctrlActions = new ControlActions();
    this.columns = "ID,FirstName,SecondName,LastName1,LastName2,Email,BirthDate,PhoneNumber,Status";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblUsersId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblUsersId, true);
    }

    this.Create = function () {
        var userData = {};
        userData = this.ctrlActions.GetDataForm('frmEdition');



        if (userData.Password != userData.Confirm || userData.Password == '' || userData.Confirm == '' ) {

            inputClave.classList.add('is-invalid');
            inputConfirma.classList.add('is-invalid');

            Swal.fire({
                title: 'Password Confirmation ',
                text: 'Please check if Password or Confirmation matches or if any of them are in blank',
                type: 'warning',
                confirmButtonText: 'Entendido'
            });


        } else {


            inputClave.classList.remove('is-invalid');
            inputConfirma.classList.remove('is-invalid');

            //Hace el post al create
            this.ctrlActions.PostToAPI(this.service, userData);

            Swal.fire({
                title: 'Registro completo',
                text: 'El usuario se registró correctamente',
                type: 'success',
                confirmButtonText: 'Entendido'
            });
            //Refresca la tabla
            this.ReloadTable();
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
