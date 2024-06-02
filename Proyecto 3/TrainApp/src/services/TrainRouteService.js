export function GetTrainRoutes() {
    return fetch('https://localhost:7048/api/routes')
        .then(response => response.json())
        .then(data => data);
}