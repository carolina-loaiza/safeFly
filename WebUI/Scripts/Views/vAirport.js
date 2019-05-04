function vAirport() {

    this.tblAirportId = "tblAirports";
    this.service = "Airport";
    this.serviceActivate = "Airport/Activar";
    this.ctrlActions = new ControlActions();
    this.ctrlAirports = new airports();
    this.columns = "LegalNumber,NameAirport,BusinessName,Administrator,Email,Latitude,Longitude,Representative,RepresentativeID,Estado";

    $("#txtLegalNumber").prop("disabled", false); //Disable
    $("#txtRepresentativeID").prop("disabled", false); //Disable

    this.SetInformation = function () {
        window.location.href = '/Dashboard/createAirport';
    }

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblAirportId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblAirportId, true);
    }

    this.Create = function () {
        var airportData = {};
        airportData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, airportData);
        //Refresca la tabla
        this.ReloadTable();
    }

    this.Update = function () {

        var airportData = {};
        airportData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.PutToAPI(this.service, airportData);
        //Refresca la tabla
        this.ReloadTable();

    }

    this.Delete = function () {

        var airportData = {};
        airportData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, airportData);
        Swal.fire({
            title: 'Desactivación correcta',
            text: 'El aeropuerto se desactivo correctamente',
            type: 'sucess',
            confirmButtonText: 'Entendido'
        });
        //Refresca la tabla
        this.ReloadTable();

    }

    this.Activar = function () {

        var airportData = {};
        airportData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.ActivarToAPI(this.serviceActivate, airportData);
        Swal.fire({
            title: 'Activación completa',
            text: 'El aeropuerto se activo correctamente',
            type: 'success',
            confirmButtonText: 'Entendido'
        });
        //Refresca la tabla
        this.ReloadTable();

    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
        sessionStorage.setItem('airportData', JSON.stringify(data));
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vairport = new vAirport();
    vairport.RetrieveAll();
});