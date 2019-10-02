var browser = null;
var parameters = null;

mp.events.add("createBrowser", (url, arguments) => {
	if(arguments == null) arguments = [];
	if(browser == null)
		browser = mp.browsers.new(`package://${url}`);
	else
		browser.url = `package://${url}`;
	parameters = arguments.length === 0 ? null : arguments;
	mp.gui.cursor.show(true, true);
	mp.gui.chat.activate(false);
	mp.gui.chat.show(false);
});

mp.events.add("hideBrowser", () => {
	if(browser == null) return;
	browser.destroy();
	mp.gui.cursor.show(false, false);
	mp.gui.chat.activate(true);
	mp.gui.chat.show(true);
	browser = null;
});

mp.events.add("executeBrowser", (fnc) => {
	if(browser == null) return;
	browser.execute(fnc);
});

mp.events.add("onBrowserReady", () => {
	if(browser === null || parameters === null || parameters["ReadyEvent"] === null) return;
	mp.events.callRemote(parameters["ReadyEvent"]);
});