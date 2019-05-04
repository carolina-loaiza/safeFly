function vBusinessPremises() {

    this.tblBusinessId = "tblBusiness";
    this.service = "BusinessPremises";
    this.serviceActivar = "BusinessPremises/Activar";
    this.ctrlActions = new ControlActions();
    this.columns = "ID,AirportID,AlquilerAmount,Description,Tenant,TenantID,Phone,Area,ComerceNumber";

    let id = document.querySelector('#txtID');
    let airportid = document.querySelector('#txtAirportID');
    let alquileramount = document.querySelector('#txtAlquilerAmount');
    let description = document.querySelector('#txtDescription');
    let tenant = document.querySelector('#txtTenant');
    let tenantid = document.querySelector('#txtTenantID');
    let phone = document.querySelector('#txtPhone');
    let area = document.querySelector('#txtArea');
    let comercenumber = document.querySelector('#txtComerceNumber');

    //$("#btnUpdate").prop("disabled", true); //Disable

    this.RetrieveAll = function () {
        //$("#txtID").prop("disabled", false); //Disable
        //$("#txtTenantID").prop("disabled", false); //Disable
        this.ctrlActions.FillTable(this.service, this.tblBusinessId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblBusinessId, true);
    }

    this.Create = function () {
        var businessData = {};
        businessData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, businessData);
        Swal.fire({
            title: 'Registro completo',
            text: 'El local comercial se registró correctamente',
            type: 'success',
            confirmButtonText: 'Entendido'
        });
        this.LimpiarFormulario();
        //Refresca la tabla
        this.ReloadTable();
    }

    this.Update = function () {

        var businessData = {};
        businessData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el put al create
        this.ctrlActions.PutToAPI(this.service, businessData);
        Swal.fire({
            title: 'Modificación completa',
            text: 'El local comercial se modificó correctamente',
            type: 'success',
            confirmButtonText: 'Entendido'
        });
        //Refresca la tabla
        this.ReloadTable();

    }

    this.Delete = function () {

        var businessData = {};
        businessData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, businessData);
        Swal.fire({
            title: 'Desactivación correcta',
            text: 'El local comercial se desactivó correctamente',
            type: 'sucess',
            confirmButtonText: 'Entendido'
        });
        //Refresca la tabla
        this.ReloadTable();

    }

    this.Activar = function () {

        var businessData = {};
        businessData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        Swal.fire({
            title: 'Activación completa',
            text: 'El local comercial se activó correctamente',
            type: 'success',
            confirmButtonText: 'Entendido'
        });
        this.ctrlActions.ActivarToAPI(this.serviceActivar, businessData);
        //Refresca la tabla
        this.ReloadTable();
    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
        $("#txtID").prop("disabled", true); //Disable
        $("#txtTenantID").prop("disabled", true); //Disable
    }

    this.LimpiarFormulario = function () {
        id.value = '';
        airportid.value = '';
        alquileramount.value = '';
        description.value = '';
        tenant.value = '';
        tenantid.value = '';
        phone.value = '';
        area.value = '';
        comercenumber.value = '';
    }
}
//ON DOCUMENT READY
$(document).ready(function () {

    var vbusiness = new vBusinessPremises();
    vbusiness.RetrieveAll();

});