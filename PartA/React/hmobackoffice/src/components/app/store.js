import { configureStore } from '@reduxjs/toolkit'
import listOfMembersReducer from '../features/listOfMembers/listOfMembersSlice'
import cardReducer from '../features/card/cardSlice'
import statisticsReducer from '../features/statistics/statisticsSlice'

export const store = configureStore({
    reducer: {
        members: listOfMembersReducer,
        card: cardReducer,
        statistics: statisticsReducer
    },
})