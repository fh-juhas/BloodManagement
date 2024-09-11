document.addEventListener('DOMContentLoaded', function () {
    loadDonors();

    document.getElementById('createDonorBtn').addEventListener('click', function () {
        openDonorModal();
    });

    document.getElementById('saveDonorBtn').addEventListener('click', function () {
        saveDonor();
    });
});

function loadDonors() {
    axios.get('/api/Donor/GetAllDonors')
        .then(function (response) {
            const donors = response.data;
            const tableBody = document.querySelector('#donorTable tbody');
            tableBody.innerHTML = '';
            donors.forEach(function (donor) {
                const row = `
                    <tr>
                        <td>${donor.donorName}</td>
                        <td>${donor.bloodGroupId}</td>
                        <td>${donor.phoneNumber}</td>
                        <td>${donor.email}</td>
                        <td>
                            <button onclick="editDonor('${donor.donorId}')" class="btn btn-sm btn-warning">Edit</button>
                            <button onclick="deleteDonor('${donor.donorId}')" class="btn btn-sm btn-danger">Delete</button>
                        </td>
                    </tr>
                `;
                tableBody.innerHTML += row;
            });
        })
        .catch(function (error) {
            console.error('Error loading donors:', error);
        });
}

function openDonorModal(donorId = null) {
    if (donorId) {
        // Edit mode
        axios.get(`/api/Donor/GetDonorbyId/${donorId}`)
            .then(function (response) {
                const donor = response.data;
                document.getElementById('donorId').value = donor.donorId;
                document.getElementById('donorName').value = donor.donorName;
                document.getElementById('bloodGroupId').value = donor.bloodGroupId;
                document.getElementById('phoneNumber').value = donor.phoneNumber;
                document.getElementById('email').value = donor.email;
                $('#donorModal').modal('show');
            })
            .catch(function (error) {
                console.error('Error loading donor:', error);
            });
    } else {
        // Create mode
        document.getElementById('donorForm').reset();
        document.getElementById('donorId').value = '';
        $('#donorModal').modal('show');
    }
}

function saveDonor() {
    const donorData = {
        donorId: document.getElementById('donorId').value,
        donorName: document.getElementById('donorName').value,
        bloodGroupId: document.getElementById('bloodGroupId').value,
        phoneNumber: document.getElementById('phoneNumber').value,
        email: document.getElementById('email').value
    };

    const url = donorData.donorId ? `/api/Donor/UpdateDonor/${donorData.donorId}` : '/api/Donor/CreateDonor';
    const method = donorData.donorId ? 'put' : 'post';

    axios({
        method: method,
        url: url,
        data: donorData
    })
        .then(function (response) {
            $('#donorModal').modal('hide');
            loadDonors();
        })
        .catch(function (error) {
            console.error('Error saving donor:', error);
        });
}

function editDonor(donorId) {
    openDonorModal(donorId);
}

function deleteDonor(donorId) {
    if (confirm('Are you sure you want to delete this donor?')) {
        axios.delete(`/api/Donor/DeleteDonor/${donorId}`)
            .then(function (response) {
                loadDonors();
            })
            .catch(function (error) {
                console.error('Error deleting donor:', error);
            });
    }
}