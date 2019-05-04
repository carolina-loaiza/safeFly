function vDashboard() {
       var userName = $('#dashboard-user_name');
       var user = JSON.parse(sessionStorage.getItem("user"));
       var linksMenu = [];
       var ctrlActions = new ControlActions();
       
        if (!user || !user.FirstName) {
             window.location.href = '/';
        }
       userName.append(user.FirstName + ' ' + user.LastName1 + ' ' +user.LastName2 );

        
        switch(user.RolName) {
          case "Registered Final User":
             linksMenu = ['listAirport'];
            break;
          case "AdminAeropuerto":
            linksMenu = ['listAirline','modifyAirport', 'listBusinessPremises', 'createBusinessPremises', 'approveAirline'];
            break;
          case "AdminAerolinea":
            linksMenu = ['listAirport','modifyAirline'];
            break;
          case "SysAdmin":
            linksMenu = ['listAdminAirport','listAirline','createAdminAirport','createAirport', 'listAirport','createCoin', 'listCoin','VPermiseC', 'VPermiseU','VPermiseL', 'VTaxC','VTaxU', 'VTaxL','VViewC', 'VViewU', 'VViewL'];
            break;
          default:
             linksMenu = [];
        }
        
       linksMenu.forEach(function(view){
          $("#link-"+view).removeClass( "d-none" );
        });
      
      this.logoutUser = function () {
         sessionStorage.removeItem("user");
          window.location.href = '/';
      }
        
}

$(document).ready(function () {

    var vdashboard = new vDashboard();
});