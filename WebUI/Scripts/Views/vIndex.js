function vIndex() {

	this.chartId = 'coinChart';
	this.service = 'coin';
	this.ctrlActions = new ControlActions();

	this.GetDataToChart = function (initializeChartFunction) {

		this.ctrlActions.GetToApi(this.service + '?type=coins', initializeChartFunction);
	};


}