import { createAsyncThunk, createSlice } from "@reduxjs/toolkit"
import { getAllMembersFromServer, deleteVaccinationsFromServer, putMemberFromServer, postMemberFromServer, deleteMemberFromServer } from './listOfMemberApi'

const initialState = {
    allMembers: [],
}

export const saveAllMembers = createAsyncThunk(
    'listOfMembersSlice/saveAllMembers', async (thunkAPI) => {
        const res = await getAllMembersFromServer();
        return res;
    }
)
export const deleteMember = createAsyncThunk(
    'listOfMembersSlice/deleteMember', async (id, thunkAPI) => {
        await deleteMemberFromServer(id);
    }
)
export const deleteVaccinations = createAsyncThunk(
    'listOfMembersSlice/deleteVaccinations', async (id, thunkAPI) => {
        await deleteVaccinationsFromServer(id);
    }
)
export const addMember = createAsyncThunk(
    'listOfMembersSlice/addMember', async (member, thunkAPI) => {
        const res = await postMemberFromServer(member);
        return res;
    }
)
export const updateMember = createAsyncThunk(
    'listOfMembersSlice/updateMember', async (memberWithId, thunkAPI) => {
        const res = await putMemberFromServer(memberWithId.id, memberWithId.member);
        return res;
    }
)

export const listOfMembersSlice = createSlice({
    name: 'listOfMembers',
    initialState,
    reducers: {

    },
    extraReducers: (builder) => {
        builder.addCase(saveAllMembers.fulfilled, (state, action) => {
            state.allMembers = action.payload
        }).addCase(deleteMember.fulfilled, (state, action) => {
            let index = state.allMembers.findIndex(x => x.id == action.payload)
            state.allMembers.splice(index, 1)
        }).addCase(addMember.fulfilled, (state, action) => {
            state.allMembers.push(action.payload)
        }).addCase(updateMember.fulfilled, (state, action) => {
            let index = state.allMembers.findIndex(x => x.id == action.payload.id)
            state.allMembers.splice(index, 1)
            state.allMembers.push(action.payload)
        })
    }
})
export const { } = listOfMembersSlice.actions
export default listOfMembersSlice.reducer