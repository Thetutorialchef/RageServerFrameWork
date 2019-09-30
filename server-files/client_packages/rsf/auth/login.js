mp.events.add('ShowLoginForm', () => {
    var start_camera = mp.cameras.new("start", {x: -1483.709, y: 160.6735, z: 54.92348}, {x:0, y:0, z:-30}, 60.0);
    start_camera.pointAtCoord(-1503.526, 136.57, 55.65308);
    start_camera.setActive(true);

    var end_camera = mp.cameras.new("end", {x: -1539.865, y: 121.2464, z: 111.8135}, {x:0, y:0, z:-30}, 60.0);
    end_camera.pointAtCoord(-1129.835, -125.4717, 231.0006);
    end_camera.setActiveWithInterp(start_camera.handle, 30000, 0, 0);

    mp.game.cam.renderScriptCams(true, false, 0, true, false);
    mp.players.local.position = new mp.Vector3(-1473.709, 160.6735, 54.92348);
    
//mp.gui.chat.activate(false);
   // mp.gui.chat.show(false);
    //mp.gui.cursor.visible = true;
    
    mp.events.call('ResetCharacterCreation');
    mp.events.call('createBrowser','rsf/assets/views/login.html');    // ['package://rsf/assets/views/login.html']);
});

mp.events.add('ShowCharacterSelection', () => {
    mp.events.call('ShowCharacterSelector');
});

mp.events.add('LoginError', (message) => {
    mp.events.call('executeFunction', ['ShowError', message]);
});
mp.events.add('RegisterError', (message) => {
    mp.events.call('executeFunction', ['ShowError', message]);
});  

mp.events.add('cef:login', (username, password) => {
    mp.events.callRemote("LoginAttempt", password);
});

mp.events.add('cef:register', (password, email) => {
    mp.events.callRemote("RegisterAttempt", password, email);
});

mp.events.add('showRegisterPage', () => {
    mp.events.call('createBrowser','rsf/assets/views/register.html');  //['package://rsf/assets/views/register.html']);
});

mp.events.add('showLoginPage', () => {
    mp.events.call('createBrowser','rsf/assets/views/login.html'); // ['package://rsf/assets/views/login.html']);
});
