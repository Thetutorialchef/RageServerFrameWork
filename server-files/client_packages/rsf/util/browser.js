var browser = null;
var parameters = [];

mp.events.add("createBrowser", (url, arguments) => {
	mp.gui.chat.push("createBrowser");
	if(browser == null)
		browser = mp.browsers.new(`package://${url}`);
	else
		browser.url = `package://${url}`;
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