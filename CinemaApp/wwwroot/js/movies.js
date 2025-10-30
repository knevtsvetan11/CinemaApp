$(document).ready(function () {
    // Намираме всички бутони с клас 'view-details-btn' и добавяме слушател за събитие
    $('.view-details-btn').on('click', function (e) {
        e.preventDefault();

        var movieId = $(this).data('movie-id');
        var modal = $('#movieDetailsModal');
        var modalTitle = modal.find('.modal-title');
        var modalBody = modal.find('#movieDetailsContent');

        // Показваме, че се зарежда съдържанието
        modalBody.html('<div class="text-center"><i class="fas fa-spinner fa-spin fa-2x"></i> Loading...</div>');

        // AJAX заявка към сървъра за детайлите на филма
        $.ajax({
            url: `/Movie/GetMovieDetails/${movieId}`,
            type: 'GET',
            success: function (response) {
                // При успешно зареждане, попълваме модалния прозорец
                modalTitle.text(response.title);
                modalBody.html(
                    '<div class="row">' +
                    '<div class="col-md-4">' +
                    '<img src="' + response.imageUrl + '" class="img-fluid rounded">' +
                    '</div>' +
                    '<div class="col-md-8">' +
                    '<p><strong>Director:</strong> ' + response.director + '</p>' +
                    '<p><strong>Description:</strong> ' + response.description + '</p>' +
                    '<p><strong>Duration:</strong> ' + response.duration + ' minutes</p>' +
                    // Можеш да добавиш и други данни, които се връщат от сървъра
                    '</div>' +
                    '</div>'
                );

                // Показваме модалния прозорец
                var myModal = new bootstrap.Modal(document.getElementById('movieDetailsModal'));
                myModal.show();
            },
            error: function (error) {
                // Ако има грешка, показваме съобщение
                modalTitle.text('Error');
                modalBody.html('<p class="text-danger">Could not load movie details. Check the server-side action.</p>');
                console.error("Error fetching movie details:", error);
            }
        });
    });
});