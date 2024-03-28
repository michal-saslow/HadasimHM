import axios from 'axios'

export const getVaccinationsForMemberFromServer=async(id)=>{
    const res=await axios.get("https://localhost:7284/api/VaccinationForMember/member/"+id);
    return res.data;
}
export const getAllVaccinationsFromServer=async()=>{
    const res=await axios.get("https://localhost:7284/api/Vaccinations");
    return res.data;
}