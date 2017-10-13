(function () {

    requestToken = (function (user, pw) {
        $.ajax({
            url: '/token',
            type: 'POST',
            contentType: 'application/json',
            data: {
                userName: "bbesart-k@msn.com",
                password: "Tech@test123",
                grant_type: 'password'
            },
            success: function (response) {
                sessionStorage.setItem('accessToken', response.acces_token)
                console.log(response)
            }
        });
    })();

    return {
        Authenticate: this.requestToken
    }

})();



