import requests
from aiogram import types
from aiogram.dispatcher.filters.builtin import CommandStart
from loader import dp, root_path
from states.userData import UserData
from aiogram.dispatcher import FSMContext

barer_tokens = {}

@dp.message_handler(CommandStart())
async def bot_start(message: types.Message):
    full_request = f"{root_path}Users/CheckUser/{message.from_user.id}"
    check_user = requests.get(full_request, verify=False)
    id = check_user.json()
    
    if check_user.status_code == 200:
        await message.answer(f"Salom, {message.from_user.full_name}!")
    else:
        await message.answer("Iltimos telefon raqamingizni yuboring.")
        await UserData.phoneNum.set()

@dp.message_handler(state=UserData.phoneNum)
async def get_phone_num(msg : types.Message, state: FSMContext):
    await state.update_data(
        {
            "phone" : msg.text
        }
    )

    await msg.answer("Parolingizni kiriting: ")
    await UserData.pasword.set()

@dp.message_handler(state=UserData.pasword)
async def get_phone_num(msg : types.Message, state: FSMContext):
    full_request = f"{root_path}Auth/login"
    password = msg.text
    data = await state.get_data()
    phone = str(data['phone'])

    if phone.startswith("+"):
        phone = phone
    else:
        phone = "+" + phone
    headers = {
    'accept': '*/*',
    'Content-Type': 'application/json',
    }

    data = {
    'phoneNumber': phone,
    'password': password,
    }

    response = requests.post(full_request, headers=headers, json=data, verify=False)

    if response.status_code == 200:
        await msg.delete()
        full_request_phone = f"{root_path}Users/phone-number?phoneNumber=%2B{phone[1:]}"
        get_user_data = requests.get(full_request_phone, verify=False).json()
        id = get_user_data['id']
        full_request_change= f"{root_path}Users/{id}/telegram/{msg.from_user.id}"
        responseput = requests.put(full_request_change, headers=headers, verify=False)
        if responseput.status_code == 200:
            await msg.answer("Muvafaqiyatli ro'yxatdan o'tingiz.")

    else:
        await msg.delete()
        await msg.answer("Parol yoki Telefon raqam xato kiritildi.\nIltimos qaytadan urinib ko'ring.")
        await state.finish()
        await msg.answer("/start - bosing")