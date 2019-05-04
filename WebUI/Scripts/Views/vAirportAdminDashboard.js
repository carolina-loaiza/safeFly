function vAirportAdminDashboard() {

	this.chartId = 'myChart';
	this.service = 'businessPremises';
	this.ctrlActions = new ControlActions();

	this.GetDataToChart = function (initializeChartFunction) {

		this.ctrlActions.GetToApi(this.service + '?type=rentRange', initializeChartFunction);
		this.ctrlActions.GetToApi(this.service + '?type=activeInactiveAirlines', initializeChartFunction);
		
	};


}