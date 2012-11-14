/// <reference path="../Scripts/jquery-1.6.4-vsdoc.js" />
/// <reference path="../Scripts/jquery.signalR-1.0.0-alpha1.js" />

(function () {
    $(function () {

        var conn = $.connection('/chat'),
            $btnInput = $('#sendBtn'),
            $msgInput = $('#msgTxt'),
            $msgContainer = $('#msgContainer');

        conn.received(function (data) {

            $msgContainer.append($('<li>').text(data));
        });

        conn.start().done(function () {

            $msgInput.focus();

            $btnInput.click(function () {

                sendMessage();
            });

            $msgInput.keypress(function (e) {
                var code = (e.keyCode ? e.keyCode : e.which);
                if (code === 13) {
                    sendMessage();
                }
            });
        });

        function sendMessage() {

            if ($msgInput.val() !== null & $msgInput.val().length > 0) {
                conn.send($msgInput.val());
                $msgInput.val(null);
            }

            $msgInput.focus();
        }
    });
}());