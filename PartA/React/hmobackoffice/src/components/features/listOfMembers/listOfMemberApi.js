import axios from 'axios'

export const getAllMembersFromServer = async () => {
    const res = await axios.get("https://localhost:7284/api/Members");
    return res.data;
}
export const deleteMemberFromServer = async (id) => {
    await axios.delete("https://localhost:7284/api/Members/" + id);
}
export const deleteVaccinationsFromServer = async (id) => {
    await axios.delete("https://localhost:7284/api/VaccinationForMember/member/" + id);
}
export const postMemberFromServer = async (member) => {
    const res = await axios.post("https://localhost:7284/api/Members", member);
    return res.data;
}
export const putMemberFromServer = async (id, member) => {
    const res = await axios.put("https://localhost:7284/api/Members/" + id, member);
    return res.data;
}
