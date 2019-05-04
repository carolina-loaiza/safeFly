
function airports() {

    this.service = "Airport";
    this.ctrlActions = new ControlActions();
    this.columns = "LegalNumber,NameAirport,BusinessName,Administrator,Email,Latitude,Longitude,Representative,RepresentativeID,Estado";
    $("#txtLegalNumber").prop("disabled", false); //Disable
    $("#txtRepresentativeID").prop("disabled", false); //Disable

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
        window.location.href = '/Dashboard/listAirport';
    }

    this.BindFields = function (data) {
        document.getElementById('btnCreate').style.visibility = 'hidden';
        document.getElementById('btnUpdate').style.visibility = 'hidden';
        this.ctrlActions.BindFields('frmEdition', data);
    }

}

$(document).ready(function () {

    var data = JSON.parse(sessionStorage.getItem('airportData'));

    var vairport = new airports();
    vairport.BindFields(data);
    $("#txtLegalNumber").prop("disabled", true); //Disable
    $("#txtRepresentativeID").prop("disabled", true); //Disable
});