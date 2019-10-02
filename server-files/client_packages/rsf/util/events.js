mp.events.add("CallServerEvent", (eventname, params) => {
	mp.events.callRemote(eventname, params);
});