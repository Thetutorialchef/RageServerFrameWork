"use strict";
//Authentification
require('./rsf/auth/login.js');


//UTIL


var browser = null;
mp.events.add("createBrowser", (url) => {
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

// Browser Fehlt