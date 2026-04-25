import { createContext, useContext, useEffect, useState } from "react";
import { jwtDecode } from "jwt-decode";

const AuthContext = createContext();

/* ===== CLAIM KONSTANTE (ASP.NET) ===== */
const ROLE_CLAIM =
  "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
const NAME_CLAIM =
  "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";

/* ===== HELPER: decode + normalize user ===== */
const decodeToken = (token) => {
  try {
    const decoded = jwtDecode(token);

    const now = Date.now() / 1000;
    if (!decoded.exp || decoded.exp <= now) {
      return null;
    }

    return {
      token,
      username: decoded[NAME_CLAIM] ?? null,
      role: decoded[ROLE_CLAIM] ?? null,
      exp: decoded.exp,
    };
  } catch {
    return null;
  }
};

export const AuthProvider = ({ children }) => {
  /* ===== USER STATE ===== */
  const [user, setUser] = useState(() => {
    const savedToken = localStorage.getItem("token");
    if (!savedToken) return null;

    const decodedUser = decodeToken(savedToken);
    if (!decodedUser) {
      localStorage.removeItem("token");
      return null;
    }

    return decodedUser;
  });

  /* ===== AUTO LOGOUT ON EXP ===== */
  useEffect(() => {
    if (!user) return;

    const timeLeft = user.exp - Date.now() / 1000;

    if (timeLeft <= 0) {
      logout();
      return;
    }

    const timeout = setTimeout(logout, timeLeft * 1000);
    return () => clearTimeout(timeout);
  }, [user]);

  /* ===== ACTIONS ===== */
  const login = (jwtToken) => {
    const decodedUser = decodeToken(jwtToken);

    if (!decodedUser) {
      logout();
      return;
    }

    localStorage.setItem("token", jwtToken);
    setUser(decodedUser);
  };

  const logout = () => {
    localStorage.removeItem("token");
    setUser(null);
  };

  /* ===== HELPERS ===== */
  const isAuthenticated = !!user;
  const hasRole = (role) => user?.role === role;

  return (
    <AuthContext.Provider
      value={{
        token: user?.token ?? null,
        user,
        username: user?.username ?? null,
        userRole: user?.role ?? null,
        isAuthenticated,
        hasRole,
        login,
        logout,
      }}
    >
      {children}
    </AuthContext.Provider>
  );
};

/* ===== HOOK ===== */
export const useAuth = () => {
  const ctx = useContext(AuthContext);
  if (!ctx) {
    throw new Error("useAuth must be used within AuthProvider");
  }
  return ctx;
};
