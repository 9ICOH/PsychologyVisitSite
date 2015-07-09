var app = angular.module('app', []);

function handleFileSelect(evt) {
    evt.stopPropagation();
    evt.preventDefault();

    var files = evt.dataTransfer.files; // FileList object.

    for (var i = 0, f; f = files[i]; i++) {

        if (!f.type.match('image.*')) continue;

        var fr = new FileReader();
        fr.onload = (function () {
            return function (ev) {
                var li = document.createElement('li');
                var div = document.createElement('div');
                div.id = "img_wrapper";
                var img = document.createElement('img');

                img.src = ev.target.result;
                div.appendChild(img);
                li.appendChild(div);
                document.getElementById('list').insertBefore(li, null);
            };
        })(f);
        fr.readAsDataURL(f);
    }
}

function handleDragOver(evt) {
    evt.stopPropagation();
    evt.preventDefault();
    evt.dataTransfer.dropEffect = 'copy'; // Explicitly show this is a copy.
}