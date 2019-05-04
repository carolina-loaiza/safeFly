function vPassword() {

  //  this.tblUsersId = 'tblUsers';
    this.service = 'password';
  //  this.serviceActivate = "user/Activar";
    this.ctrlActions = new ControlActions();
    this.columns = "Email,Password";

  //  this.RetrieveAll = function () {
  //      this.ctrlActions.FillTable(this.service, this.tblUsersId, false);
  //  }

 //   this.ReloadTable = function () {
  //      this.ctrlActions.FillTable(this.service, this.tblUsersId, true);
 //   }

    this.Create = function () {
        var passData = {};
        passData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, passData);
        Swal.fire({
            title: 'Registro completo',
            text: 'El usuario se registró correctamente',
            type: 'success',
            confirmButtonText: 'Entendido'
        });
        //Refresca la tabla
        this.ReloadTable();
    }

    this.Update = function () {

        var passData = {};
        passData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.PutToAPI(this.service, passData);
        Swal.fire({
            title: 'Modificación completa',
            text: 'El usuario se modificó correctamente',
            type: 'success',
            confirmButtonText: 'Entendido'
        });
        //Refresca la tabla
        this.ReloadTable();

    }

    this.Delete = function () {

        var passData = {};
        passData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, passData);
        Swal.fire({
            title: 'Desactivación correcta',
            text: 'El usuario se desactivo correctamente',
            type: 'error',
            confirmButtonText: 'Entendido'
        });
        //Refresca la tabla
        this.ReloadTable();

    }

    

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vpass = new vPassword();
  //  vuser.RetrieveAll();

});
