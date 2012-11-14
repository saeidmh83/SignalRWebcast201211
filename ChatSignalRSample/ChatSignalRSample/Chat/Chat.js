/// <reference path="../Scripts/jquery-1.6.4-vsdoc.js" />
/// <reference path="../Scripts/jquery.signalR-1.0.0-alpha1.js" />


(function () {

    var hub = $.connection.chatHub,
        $btnInput = $('#sendBtn'),
        $msgInput = $('#msgTxt'),
        $msgContainer = $('#msgContainer');

    hub.client.received = function (msg) {
        $msgContainer.append($('<li>').text(msg));
    };

    $.connection.hub.start().done(function () {

        $msgInput.focus();

        $btnInput.click(function () {

            sendMessage();
        });

        $msgInput.keypress(function(e) {
            var code = (e.keyCode ? e.keyCode : e.which);
            if (code === 13) {
                sendMessage();
            }
        });

    });

    function sendMessage() {

        if ($msgInput.val() !== null & $msgInput.val().length > 0) {
            hub.server.send($msgInput.val());
            $msgInput.val(null);
        }

        $msgInput.focus();
    }
}());