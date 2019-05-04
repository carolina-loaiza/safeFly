class VView extends BaseClass{
    constructor() {
        super("view", "tblView", "frmView");
    }
    Create() {
        const data = this.ctrlActions.GetDataForm(this._form);
        data.status = "active";
        this.ctrlActions.PostToAPI(this.service, data);
        this.ReloadTable();
        document.querySelector(`${this._form}`).reset();
    }
    Update() {

        let data = {};
        data = this.ctrlActions.GetDataForm(this._form);
        let status = document.querySelector("#Status");
        if (status) data.Status = status.checked;
        //Hace el post al create
        this.ctrlActions.PutToAPI(this.service, data);
        //Refresca la tabla
        this.ReloadTable();
        this.getForm().reset();

    }
}