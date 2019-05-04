function vAirportAdmin() {

    const inputClave = document.querySelector('#txtPassword');
    const inputConfirma = document.querySelector('#txtConfirmPass');

    this.service = 'user';
    this.ctrlActions = new ControlActions();

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
                $('#container-spinner').addClass('d-none');
                Swal.fire({
                    title: 'Account created!',
                    type: 'success',
                    confirmButtonText: 'Ok'
                  }).then((result) => {
                          window.location.href = '/Dashboard/user';
                  });
                  CtrlActions.PostToAPI("userxrolexview", {
                        "UserId": userData.ID,
                        "RoleId": 2,
                        "ViewId": 3
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
}

$(document).ready(function () {
    var vairportAdmin = new vAirportAdmin();   
});
