$(document).ready(function () {
    $('.btn-clear').click(function () {
        var s = $('input[name=surname]').val('');
        $('input[name=iin]').val('');
    })
    $('i[class^=btnMenu]').click(function () {
        if ($('i[class^=btnMenu]').attr('value') == 1) {
            $('.mynav > .container').slideUp(1000)
            $('i[class^=btnMenu]').attr('value', 0)
            $('.mynav').height(15);
        }
        else {
            $('.mynav > .container').slideDown(1000);
            $('i[class^=btnMenu]').attr('value', 1)
            $('.mynav').height(56);


        }
    })

    var PlaceHolderElement = $('#PlaceHolderHere')
    $('button[data-toggle=ajax-modal]').click(function (event) {
        var id = $(this).data('id');
        var url = $(this).data('url') + '/' + id;
        $.get(url).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show')
        })
    })

    PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
        var form = $(this).parents('.modal').find('form');
        var actionUrl = $('form[action="AddPatient"]').attr('action')
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (data) {
            PlaceHolderElement.find('.modal').modal('hide');
            window.location.reload();
        })

    })

    PlaceHolderElement.on('click', '[data-edit="modal"]', function (event) {
        var form = $(this).parents('.modal').find('form');
        var actionUrl = $('form[action="EditPatient"]').attr('action')
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (data) {
            PlaceHolderElement.find('.modal').modal('hide');
            window.location.reload();

        })
    })

});
