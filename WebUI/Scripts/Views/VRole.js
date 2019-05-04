class VRole extends BaseClass {
    constructor() {
        super("role", "tblRole", "frmRole", "VPermiseU");
    }

    Create() {
        const data = this.ctrlActions.GetDataForm(this._form);
         if (!data) {
            return false;
        }
        data.status = "active";
        $.post(this.ctrlActions.GetUrlApiService(this.service), data, function (response) {            
            Swal.fire({
                title: 'Role created! ',
               type: 'success',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Ok'
             }).then((result) => {
                   window.location.href = '/Dashboard/VPermiseL';
              })
        })
        .fail(function (response) {
               Swal.fire({
                    title: 'An error has occurred',
                    text: 'Please check the information and try again.',
                   type: 'error',
                    confirmButtonText: 'OK'
               });
         })

    }
    
    BindFields() {
        var view = window.location.href;
        var dataModify = JSON.parse(sessionStorage.getItem("tblRole_selected"));
        
        if (window.location.href.includes('VPermiseU')) {
             this.ctrlActions.BindFields('frmRole', dataModify);
        }
    }

    Update() {
        let data = {};
        data = this.ctrlActions.GetDataForm(this._form);
       
         if (!data) {
            return false;
        }
        
        let status = document.querySelector("#Status");
        if (status) data.Status = status.checked ? "Activo" : "null";
        
       $.put(this.ctrlActions.GetUrlApiService(this.service), data, function (response) {            
            Swal.fire({
                title: 'Rol modified! ',
               type: 'success',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Ok'
             }).then((result) => {
                   window.location.href = '/Dashboard/VPermiseL';
              })
        })
        .fail(function (response) {
               Swal.fire({
                    title: 'An error has occurred',
                    text: 'Please check the information and try again.',
                   type: 'error',
                    confirmButtonText: 'OK'
               });
         })

    }
}