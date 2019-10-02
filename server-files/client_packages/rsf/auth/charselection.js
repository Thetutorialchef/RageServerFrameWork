mp.events.add("ShowCharacterSelection", (params) => {
    mp.events.call('createBrowser', "rsf/assets/views/selectcharacter.html", params);
});