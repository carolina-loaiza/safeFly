
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

//GET RATING DE VUELO
function ratingFlyJS() {
	for (i = 0; i < document.getElementsByName('rating').length; i++) {
		if (document.getElementsByName('rating')[i].checked == true) {
			var ratingValue = document.getElementsByName('rating')[i].value;
			break;
		}
	}
	alert(ratingValue);
}




//ON DOCUMENT READY
$(document).ready(function () {

	var contactus = new contactUs();
	contactus.RetrieveAll();

});

