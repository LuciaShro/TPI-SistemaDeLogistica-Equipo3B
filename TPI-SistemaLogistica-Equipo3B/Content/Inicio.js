window.onload = function () {
    const ctx = document.getElementById('miGrafico').getContext('2d');

    new Chart(ctx, {
        type: 'bar',
        data: {
            labels: etiquetasJson,
            datasets: [{
                label: 'Cantidad de usos',
                data: valoresJson,
                backgroundColor: 'rgba(75, 192, 192, 0.5)',
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                y: {
                    beginAtZero: true,
                    precision: 0
                }
            }
        }
    });
};
