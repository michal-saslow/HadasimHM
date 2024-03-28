import { createAsyncThunk, createSlice } from "@reduxjs/toolkit"
import { getVaccinationsForMemberFromServer, getAllVaccinationsFromServer } from './cardApi'


const initialState = {
    member: {
        id: 0,
        phone: "",
        firstName: "",
        lastName: "",
        cellPhone: "",
        dateOfBirth: Date,
        dateOfIllness: Date,
        dateOfRecovery: Date,
        profileImage: "",
        identity: "",
        city: {
            name: "",
            address: "",
            houseNumber: 0
        }
    },
    allVaccinationfromMember: [],
    allVaccination: []
}

export const getVaccinationsForMember = createAsyncThunk(
    'cardSlice/getVaccinationsForMember', async (id, thunkAPI) => {
        const res = await getVaccinationsForMemberFromServer(id);
        return res;
    }
)
export const getVaccinations = createAsyncThunk(
    'cardSlice/getVaccinations', async (thunkAPI) => {
        const res = await getAllVaccinationsFromServer();
        return res;
    }
)

export const cardSlice = createSlice({
    name: 'cardSlice',
    initialState,
    reducers: {

    },
    extraReducers: (builder) => {
        builder.addCase(getVaccinations.fulfilled, (state, action) => {
            state.allVaccination = action.payload
        }).addCase(getVaccinationsForMember.fulfilled, (state, action) => {
            state.allVaccinationfromMember = action.payload
        })
    }
})
export const { } = cardSlice.actions
export default cardSlice.reducer