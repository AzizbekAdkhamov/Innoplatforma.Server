from aiogram.dispatcher.filters.state import StatesGroup, State

class UserData(StatesGroup):
    phoneNum = State()
    pasword = State()