import axios from "axios";

export const getCntNotVaccinatedFromServer = async () => {
    const res = await axios.get("https://localhost:7284/api/Members/NotVaccinated");
    return res.data;
}
export const getPatientsPerDayFromServer = async () => {
    const res = await axios.get("https://localhost:7284/api/Members/PatientsPerDay");
    return res.data;
}