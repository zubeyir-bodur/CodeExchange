$(() => {
    $(document).ready(() => {
        $.get('partials/Login.html', (e) => {
            $('#container-main').empty().append(e);
        });
        $("#QuestionPage").click(() => {
            $.get('partials/Question.html', (obj) => {
                $('#container-main').empty().append(obj);
            });
        });
    });
});