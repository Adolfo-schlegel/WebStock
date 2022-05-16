
showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
            /*$("#myModal").css("z-index", "1500");*/
            /*$('#myModal').appendTo("body")*/
            /*$('#form-modal').appendTo("body").modal('show');*/

            //$('#form-modal').modal('hide');
            //if ($('.modal-backdrop').is(':visible')) {
            //    $('body').removeClass('modal-open');
            //    $('.modal-backdrop').remove();
            //};
        }
    })
}



    //$(document).ready(function(){
    //  $("#myBtn").click(function () {
    //      $("#myModal").modal({ backdrop: true });
    //  });

    //  $("#myBtn2").click(function(){
    //      $("#myModal2").modal({ backdrop: false });
    //  });

    //  $("#myBtn3").click(function(){
    //      $("#myModal3").modal({ backdrop: "static" });
    //  });
    //});







jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-all').html(res.html)
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                }
                else
                    $('#form-modal .modal-body').html(res.html);
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}