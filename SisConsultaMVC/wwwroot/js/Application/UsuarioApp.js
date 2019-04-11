"use strict";

function CadastrarUsuario(e) {
    let idForm = $(e).closest('form').attr('id');
    let obj = $('#' + idForm).serializeToJSON();
    let jsonString = JSON.stringify(obj);

    api.post(`usuario`, jsonString)
        .then(res => {
            console.log(res);
            console.log(res.data);
        });
}


//axios.post('/post/server', JSON.parse(data))
//    .then(function (res) {
//        output.className = 'container';
//        output.innerHTML = res.data;
//    })
//    .catch(function (err) {
//        output.className = 'container text-danger';
//        output.innerHTML = err.message;
//    });