
function contactUs() {

	this.service = 'contactUs';
	this.ctrlActions = new ControlActions();


	this.Create = function () {
		var contactData = {};
		contactData = this.ctrlActions.GetDataForm('frmEdition');
		//envia la info al control actions
		this.ctrlActions.PostToAPI(this.service, contactData);
		Swal.fire({
			title: 'Email send',
			text: 'The email request has been send successfully',
			type: 'success',
			confirmButtonText: 'Got it!'
		});

	}

	
}

//ON DOCUMENT READY
$(document).ready(function () {

	var contactus = new contactUs();
	contactus.RetrieveAll();

});

