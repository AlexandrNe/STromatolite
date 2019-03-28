tinymce.init({
    selector: "textarea.tiny",
    theme: "modern",
    language_url: "/Scripts/tinymce/langs/ru.js",
    menubar: false,
    plugins: [
        "advlist autolink lists link image charmap print preview hr anchor pagebreak",
        "searchreplace wordcount visualblocks visualchars code fullscreen",
        "insertdatetime media nonbreaking save table contextmenu directionality",
        "emoticons template paste textcolor"
    ],
    toolbar1: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image",
    toolbar2: "preview media | forecolor backcolor emoticons | code",
    image_advtab: true,
    insertdatetime_dateformat: "%d-%m-%Y",
    insertdatetime_timeformat: "%H:%M:%S",
    file_browser_callback: function (field_name, url, file, win) {
        tinymce.activeEditor.windowManager.open({
            file: '/filebrowser',// use an absolute path!
            title: 'Файловый проводник',
            width: 900,
            height: 450,
            resizable: 'yes'
        }, {
            setUrl: function (url) {
                win.document.getElementById(field_name).value = url;
            }
        });
        return false;
    },
    templates: [
        { title: 'Test template 1', content: 'Test 1' },
        { title: 'Test template 2', content: 'Test 2' }
    ]
});
