document.addEventListener("DOMContentLoaded", function() {
    // Function to toggle the visibility of elements
    function toggleElements() {
        var elementsToToggle = document.querySelectorAll('.card, .btn-primary, .btn-secondary');
        elementsToToggle.forEach(function(element) {
            if (element.style.display === 'none') {
                element.style.display = 'block';
            } else {
                element.style.display = 'none';
            }
        });
    }

    // Add event listener to the toggle button
    var toggleButton = document.getElementById('toggleButton');
    toggleButton.addEventListener('click', function() {
        toggleElements();
    });
});
