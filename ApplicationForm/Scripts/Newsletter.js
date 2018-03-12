$.newsletter = {
    apply: function () {
        $.app.postData({
            url: "newsletter/apply",
            data: {
                Email: document.getElementById("newsletterEmail").value
            },
            success: $.newsletter.success,
            error: $.newsletter.error,
            beforeSend: $.newsletter.beforeSend,
            complete: $.newsletter.complete
        });
    },
    success: function () {
        $.app.notify.success("Successfully applyied! <i class=\"glyphicon glyphicon-thumbs-up\"></i>");
    },
    error: function (jqXHR, textStatus, errorThrown) {
        $.app.notify.error(jqXHR.responseJSON.error);
    },
    beforeSend: function () {
        $("#newsletterSignIn").button("loading");
    },
    complete: function () {
        $("#newsletterSignIn").button("reset");
    }
}