$.app = {
    postData: function (options) {
        debugger;
        $.ajax({
            url: options.url,
            type: "json",
            method: "POST",
            data: options.data,
            success: options.success,
            error: options.error,
            complete: options.complete,
            beforeSend: options.beforeSend,
        })
    },
    notify: {
        success: function (message) {
            toastr.success(message);
        },
        error: function (message) {
            toastr.error(message);
        }
    }
}