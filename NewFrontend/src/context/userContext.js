import React, { createContext, useState, useEffect } from 'react';
import Cookie from 'js-cookie';


const UserContext = createContext({});


export const UserProvider = ({ children }) => {
    const [initialState] = useState({
        expirationDate: Date.now,
        permissionLevel: 'none',
        token: '',
        userName: '',
        wasPostRegistered: false,
    });
    const [userState, setUserState] = useState(initialState);
    const setLoginData = (data) => {
        if (!data) return;
        setUserState(data);
        Cookie.set('userData', JSON.stringify(data));
    }

    const logout = () => {
        setUserState(initialState);
        Cookie.set('userData', JSON.stringify(initialState));
    }

    useEffect(() => {
      const cookieVal = Cookie.get('userData');
      if (cookieVal) setUserState(JSON.parse(cookieVal));
    }, [Cookie])
    return (<UserContext.Provider value={{ state: [userState, setLoginData], initial: [initialState], logout }}>
            {children}
        </UserContext.Provider>)
}

export default UserContext;