$(document).ready(function () {
    const workingDoneModal = document.getElementById('workingDoneModal')
    if (workingDoneModal) {
        workingDoneModal.addEventListener('show.bs.modal', event => {
            const button = event.relatedTarget

            const id = button.getAttribute('data-id');
            const definition = button.getAttribute('data-definition');
            const description = button.getAttribute('data-description');

            const modalTitle = workingDoneModal.querySelector('.wdescription')
            const modalBodyInput = workingDoneModal.querySelector('.wdefinition')

            modalTitle.textContent = definition;
            modalBodyInput.textContent = description;

            $('#btnWorkingDone').click(function () {
                $.ajax({
                    type: "GET",
                    url: "/Member/Working/DoneTask",
                    data: { id: id },
                    dataType: "json",
                    contentType: "application/json; charset=utf-8;",
                    success: function () {
                        console.log('buraya geldi.')
                        window.location.reload();
                    },
                    error: function (error) {
                        console.log(error.statusText);
                        alert(error.statusText)
                    }
                });
            });
        });
    }
});

