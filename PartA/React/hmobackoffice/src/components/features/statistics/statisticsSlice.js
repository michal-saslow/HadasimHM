import { createAsyncThunk, createSlice } from "@reduxjs/toolkit"
import { getPatientsPerDayFromServer, getCntNotVaccinatedFromServer } from './statisticsApi'

const initialState = {
    countNotVaccinated: 0,
    patientsPerDay: []
}

export const getCntNotVaccinated = createAsyncThunk(
    'listOfMembersSlice/getCntNotVaccinated', async (thunkAPI) => {
        const res = await getCntNotVaccinatedFromServer();
        return res;
    }
)
export const getPatientsPerDay = createAsyncThunk(
    'listOfMembersSlice/getPatientsPerDay', async (thunkAPI) => {
        const res = await getPatientsPerDayFromServer();
        return res;
    }
)

export const statisticsSlice = createSlice({
    name: 'statisticsSlice',
    initialState,
    reducers: {

    },
    extraReducers: (builder) => {
        builder.addCase(getCntNotVaccinated.fulfilled, (state, action) => {
            state.countNotVaccinated = action.payload
        }).addCase(getPatientsPerDay.fulfilled, (state, action) => {
            state.patientsPerDay = action.payload
        })
    }
})
export const { } = statisticsSlice.actions
export default statisticsSlice.reducer