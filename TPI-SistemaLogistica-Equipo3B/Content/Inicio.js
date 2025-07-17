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


document.addEventListener("DOMContentLoaded", function () {
    if (typeof provinciasJson === 'undefined' || typeof cantidadesJson === 'undefined') {
        console.warn("Los datos de provincias no están disponibles");
        return;
    }

    const ctx = document.getElementById('GraficoProvincias').getContext('2d');
    const chart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: provinciasJson,
            datasets: [{
                label: 'Top 5 provincias',
                data: cantidadesJson,
                backgroundColor: 'rgba(54, 162, 235, 0.5)',
                borderColor: 'rgba(54, 162, 235, 1)',
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: { beginAtZero: true }
            }
        }
    });
});



