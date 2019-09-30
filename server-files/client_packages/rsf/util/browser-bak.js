/**
 * ForwardDevs - 2018
 */

let customBrowser = undefined;
let parameters = [];

mp.events.add('createBrowser', (arguments) => {
	mp.events.call('destroyBrowser');

	if(customBrowser === undefined) {
		parameters = arguments.slice(1, arguments.length);
		customBrowser = mp.browsers.new(arguments[0]);
	}
});

mp.events.add('browserDomReady', (browser) => {
	if(customBrowser === browser) {
		mp.gui.cursor.visible = true;

		if(parameters.length > 0) {
			mp.events.call('executeFunction', parameters);
		}
	}
});

mp.events.add('executeFunction', (arguments) => {
	let input = '';

	for(let i = 1; i < arguments.length; i++) {
		if(input.length > 0) {
			input += ', \'' + arguments[i] + '\'';
		} else {
			input = '\'' + arguments[i] + '\'';
		}
	}
    
    customBrowser.execute(`${arguments[0]}(${input});`);
});

mp.events.add('destroyBrowser', () => {
	if (customBrowser != undefined) {
		mp.gui.cursor.visible = false;
		customBrowser.destroy();
		customBrowser = undefined;
	}
});
