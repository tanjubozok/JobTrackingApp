$(document).ready(function () {
    const workingModal = document.getElementById('workingDeleteModal')
    if (workingModal) {
        workingModal.addEventListener('show.bs.modal', event => {
            const button = event.relatedTarget

            const id = button.getAttribute('data-id');
            const definition = button.getAttribute('data-definition');
            const description = button.getAttribute('data-description');

            const modalTitle = workingModal.querySelector('.wdescription')
            const modalBodyInput = workingModal.querySelector('.wdefinition')

            modalTitle.textContent = definition;
            modalBodyInput.textContent = description;

            $('#btnWorkingRemove').click(function () {
                $.ajax({
                    type: "GET",
                    url: "/Admin/Working/Delete",
                    data: { id: id },
                    dataType: "json",
                    contentType: "application/json; charset=utf-8;",
                    success: function () {
                        alert("done")
                        window.location.reload();
                    },
                    error: function (error) {
                        alert(error.statusText)
                    }
                });
            });
        });
    }
});
